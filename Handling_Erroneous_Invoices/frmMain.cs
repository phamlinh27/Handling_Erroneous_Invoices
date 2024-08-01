using Handling_Erroneous_Invoices.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using API3.SDK.Interface;
using API3.SDK;
using API3.SDK.Model;
using API3.SDK.Model.Parameter;
using API3.SDK.Model.SDKResult;
using System.Configuration;


namespace Handling_Erroneous_Invoices
{
    public partial class frmMain : Form
    {
        frmLogin _frmLogin = null;
        IInvoicePublishing InvoicePublishingObject = null;
        IInvoicePublished InvoicePublishedObject = null;
        IInvoiceCalculatingPublishing IInvoiceCalculatingPublishingObject = null;
        IInvoiceCalculatingPublished IInvoiceCalculatingPublishedObject = null;
        public frmMain(frmLogin login)
        {
            _frmLogin = login;
            InvoicePublishingObject = MeInvoiceFactory.CreateInvoicePublishingClass(Program.TaxCode, Program.TOKEN);
            InvoicePublishedObject = MeInvoiceFactory.CreateInvoicePublishedClass(Program.TaxCode, Program.TOKEN);
            IInvoiceCalculatingPublishingObject = MeInvoiceFactory.CreateInvoicePublishingCalculatingClass(Program.TaxCode, Program.TOKEN);
            IInvoiceCalculatingPublishedObject = MeInvoiceFactory.CreateCalculatingPublishedClass(Program.TaxCode, Program.TOKEN);
            InitializeComponent();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _frmLogin.Close();
        }

        private API3.SDK.Model.ServiceResult get_invoice(string TransactionID)
        {
            API3.SDK.Model.ServiceResult result = API3.SDK.CommonFunction.ExecuteApiFunction("GET", "invoiceprocessing/business", TransactionID, Program.TOKEN, "", Program.TaxCode, Program.IS_Code);
            return result;
        }

        private void btnPathChoose_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Excel file (*.txt)|*.txt";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtPathPublish.Text = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _frmLogin.Show();
            this.Hide();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItemCode.Text))
            {
                MessageBox.Show("Vui lòng không để trống Mã hàng hoá thay thế.");
            }
            else if (string.IsNullOrEmpty(txtItemCode.Text))
            {
                MessageBox.Show("Vui lòng không để trống Tên hàng hoá thay thế.");
            }
            else if (string.IsNullOrEmpty(txtPathPublish.Text))
            {
                MessageBox.Show("Vui lòng chọn tệp xử lý.");
            }
            else if (!File.Exists(txtPathPublish.Text))
            {
                MessageBox.Show("Tệp xử lý không tồn tại.");
            }
            else
            {
                string[] list_readText = File.ReadAllLines(txtPathPublish.Text);
                string folderPath = "Respone";
                if (!Directory.Exists(folderPath))
                {
                    // Tạo thư mục nếu chưa tồn tại
                    Directory.CreateDirectory(folderPath);
                }
                string file_res = $"{folderPath}/respone_{Program.TaxCode}_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.txt";
                using (StreamWriter writer = new StreamWriter(file_res))
                {
                    string last_item = list_readText.Last();
                    List<OriginalInvoiceDataCalculating> list_replace_invocie = new List<OriginalInvoiceDataCalculating>();
                    List<string> list_transactionID = new List<string>();
                    foreach (string TransactionID in list_readText)
                    {
                        ServiceResult result = get_invoice(TransactionID.Trim());
                        JsonSerializerSettings settings = new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        };
                        GetMeinvocieRespone data_meinvoice = JsonConvert.DeserializeObject<GetMeinvocieRespone>(result.Data.ToString(), settings);
                        try
                        {
                            DateTime _now = DateTime.Now;
                            bool run = false;
                            if (list_transactionID.Count < Int32.Parse(ConfigurationSettings.AppSettings["Number_Einvoice"]) - 1)
                            {
                                list_replace_invocie.Add(create_list_replace_invocie(data_meinvoice, _now));
                                list_transactionID.Add(TransactionID.Trim());
                                if (TransactionID.Trim() == last_item.Trim())
                                {
                                    run = true;
                                }
                            }
                            else
                            {
                                list_replace_invocie.Add(create_list_replace_invocie(data_meinvoice, _now));
                                list_transactionID.Add(TransactionID.Trim());
                                run = true;
                            }

                            if (run)
                            {
                                execute(list_replace_invocie, list_transactionID, _now, writer);
                                list_replace_invocie = new List<OriginalInvoiceDataCalculating>();
                                list_transactionID = new List<string>();
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                Process.Start(folderPath);
            }
        }

        private OriginalInvoiceDataCalculating create_list_replace_invocie(GetMeinvocieRespone data_meinvoice, DateTime now)
        {

            OriginalInvoiceData param_data = new OriginalInvoiceData();
            OriginalInvoiceDataCalculating originalInvoiceData = new OriginalInvoiceDataCalculating();
            Type t = typeof(OriginalInvoiceData);
            foreach (var prop in t.GetProperties())
            {
                switch (prop.Name)
                {
                    // những trường này sẽ bỏ qua
                    case "ReferenceType":
                    case "OrgInvoiceType":
                    case "OrgInvTemplateNo":
                    case "OrgInvSeries":
                    case "OrgInvNo":
                    case "OrgInvDate":
                    case "InvoiceNote":
                    case "SellerLegalName":
                    case "SellerTaxCode":
                    case "SellerAddress":
                    case "SellerPhoneNumber":
                    case "SellerEmail":
                    case "SellerBankAccount":
                    case "SellerBankName":
                    case "SellerFax":
                    case "SellerWebsite":
                    case "RefID":
                    case "ClockInfos":
                    case "InvoiceTemplateID":
                    case "FeeInfo":
                        break;
                    case "OriginalInvoiceDetail": // Xử lý riêng cho OriginalInvoiceDetail
                        List<InvoiceDataDetail> invoiceDataDetails = (List<InvoiceDataDetail>)data_meinvoice.GetType().GetProperty("InvoiceDataDetails").GetValue(data_meinvoice, null);
                        if (invoiceDataDetails.Count > 0)
                        {
                            param_data.OriginalInvoiceDetail = new List<OriginalInvoiceDetail>();
                            for (int i = 0; i < invoiceDataDetails.Count; i++)
                            {

                                OriginalInvoiceDetail detail_data = new OriginalInvoiceDetail()
                                {
                                    LineNumber = i + 1,
                                    SortOrder = invoiceDataDetails[i].ItemType == 1 || invoiceDataDetails[i].ItemType == 2 ? i + 1 : new Nullable<int>(),

                                    ItemType = invoiceDataDetails[i].ItemType,
                                    ItemCode = txtItemCode.Text,
                                    ItemName = txtItemName.Text,
                                    UnitName = invoiceDataDetails[i].UnitName,

                                    Quantity = invoiceDataDetails[i].Quantity,
                                    UnitPrice = invoiceDataDetails[i].UnitPrice,

                                    AmountOC = invoiceDataDetails[i].AmountOC,
                                    Amount = invoiceDataDetails[i].Amount,

                                    DiscountRate = invoiceDataDetails[i].DiscountRate,
                                    DiscountAmountOC = invoiceDataDetails[i].DiscountAmountOC,
                                    DiscountAmount = invoiceDataDetails[i].DiscountAmount,

                                    AmountWithoutVATOC = invoiceDataDetails[i].AmountWithoutVATOC,

                                    VATRateName = invoiceDataDetails[i].VATRateName,
                                    VATAmountOC = invoiceDataDetails[i].VATAmountOC,
                                    VATAmount = invoiceDataDetails[i].VATAmount,

                                    AmountAfterTax = invoiceDataDetails[i].AmountAfterTax,
                                    UnitPriceAfterTax = invoiceDataDetails[i].UnitPriceAfterTax
                                };
                                param_data.OriginalInvoiceDetail.Add(detail_data);
                            }

                        }
                        break;
                    case "TaxRateInfo": // Xử lý riêng cho TaxRateInfo
                        List<TaxRateInfo> taxRateInfo = (List<TaxRateInfo>)data_meinvoice.GetType().GetProperty(prop.Name).GetValue(data_meinvoice, null);
                        if (taxRateInfo != null && taxRateInfo.Count > 0)
                        {
                            param_data.TaxRateInfo = taxRateInfo;
                        }
                        break;
                    case "InvSeries":
                        param_data.GetType().GetProperty(prop.Name).SetValue(param_data, data_meinvoice.InvTemplateNo + data_meinvoice.InvSeries);
                        break;
                    default:
                        if (data_meinvoice.GetType().GetProperty(prop.Name) != null)
                        {
                            var val_of_property = data_meinvoice.GetType().GetProperty(prop.Name).GetValue(data_meinvoice, null);
                            if (val_of_property != null)
                            {
                                param_data.GetType().GetProperty(prop.Name).SetValue(param_data, val_of_property);
                            }
                        }
                        else
                        {
                            param_data.GetType().GetProperty(prop.Name).SetValue(param_data, null);
                        }

                        break;
                }
            }
            param_data.RefID = Guid.NewGuid().ToString();
            param_data.ReferenceType = 1; // (1: thay thế; 2: điều chỉnh)
            param_data.OrgInvoiceType = 1; // (1: Hóa đơn 123; 3: Hóa đơn 51)
            param_data.OrgInvTemplateNo = data_meinvoice.InvTemplateNo;
            param_data.OrgInvSeries = data_meinvoice.InvSeries;
            param_data.OrgInvNo = data_meinvoice.InvNo;
            param_data.OrgInvDate = data_meinvoice.InvDate;
            param_data.InvDate = now;
            param_data.InvoiceNote = "Do sai thông tin vật tư hàng hoá";

            List<OtherInfo> others = JsonConvert.DeserializeObject<List<OtherInfo>>(data_meinvoice.OtherInfo);
            for (int i = 0; i < others.Count; i++)
            {
                switch (others[i].FieldName)
                {
                    case "TotalSaleAmountOC":
                        param_data.TotalSaleAmountOC = Decimal.Parse(others[i].FieldValue);
                        break;
                    case "TotalSaleAmount":
                        param_data.TotalSaleAmount = Decimal.Parse(others[i].FieldValue);
                        break;
                }

            }



            if (rbCalculatingMachine.Checked)
            {
                param_data.IsInvoiceCalculatingMachine = true;
            }
            originalInvoiceData = new OriginalInvoiceDataCalculating() { OrgInvoiceData = param_data };

            return originalInvoiceData;
        }

        private void execute(List<OriginalInvoiceDataCalculating> data_meinvoice, List<string> list_transactionID, DateTime now, StreamWriter writer)
        {
            for (int i = 0; i < data_meinvoice.Count; i++)
            {
                string mess = "";
                if (rbCalculatingMachine.Checked)
                {
                    mess = list_transactionID[i] + "\t||";
                    bool res_cancel = cancel_invocie(rbCalculatingMachine.Checked, list_transactionID[i], now);
                    if (res_cancel)
                    {
                        mess += "Huỷ Hoá đơn: Thành công\t||";
                        List<OriginalInvoiceDataCalculating> _data = new List<OriginalInvoiceDataCalculating>();
                        _data.Add(data_meinvoice[i]);
                        bool res_replace = replace_invocie<OriginalInvoiceDataCalculating>(rbCalculatingMachine.Checked, _data);
                        if (res_replace)
                        {
                            mess += "Phát hành hoá đơn thay thế: Thành công";
                        }
                        else
                        {
                            mess += "Phát hành hoá đơn thay thế: Thất bại";
                        }
                    }
                    else
                    {
                        mess += "Huỷ Hoá đơn: Thất bại";
                    }
                    writer.WriteLine(mess);
                }
                else if (rbCode.Checked)
                {

                }
                else if (rbNoCode.Checked)
                {

                }
            }
        }

        private bool cancel_invocie(bool isInvoiceCalculatingMachine, string transactionID, DateTime now)
        {
            if (isInvoiceCalculatingMachine)
            {
                OperationResult result = InvoicePublishedObject.CancelInvoiceMTT(transactionID, now, "Huỷ hoá đơn do sai thông tin hàng hoá");
                if (!result.Success)
                {
                    return false;
                }
                else return true;
            }
            else
            {
                OperationResult result = InvoicePublishedObject.CancelInvoice(transactionID, now, "Huỷ hoá đơn do sai thông tin hàng hoá");
                if (!result.Success)
                {
                    return false;
                }
                else return true;
            }
            
        }

        private bool replace_invocie<T>(bool isInvoiceCalculatingMachine, List<T> originalInvoiceData)
        {
            if (isInvoiceCalculatingMachine)
            {
                if (rbNoSign.Checked)
                {
                    ListPublishInvoiceResult result = IInvoiceCalculatingPublishingObject.InvoiceAndPublish((List<OriginalInvoiceDataCalculating>)Convert.ChangeType(originalInvoiceData, typeof(List<OriginalInvoiceDataCalculating>)), Program.IS_Code);

                    if (!result.Success)
                    {
                        return false;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(result.PublishInvoices[0].ErrorCode))
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                else if (rbHSM.Checked)
                {
                    ListPublishInvoiceResult result = IInvoiceCalculatingPublishingObject.PublishInvoiceHSM((List<OriginalInvoiceDataHSM>)Convert.ChangeType(originalInvoiceData, typeof(List<OriginalInvoiceDataHSM>)), Program.IS_Code);

                    if (!result.Success)
                    {
                        return false;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(result.PublishInvoices[0].ErrorCode))
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                else { return false; }
            }
            else
            {
                if (rbHSM.Checked)
                {
                    ListPublishInvoiceResult result = IInvoiceCalculatingPublishingObject.PublishInvoiceHSM((List<OriginalInvoiceDataHSM>)Convert.ChangeType(originalInvoiceData, typeof(List<OriginalInvoiceDataHSM>)), Program.IS_Code);

                    if (!result.Success)
                    {
                        return false;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(result.PublishInvoices[0].ErrorCode))
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                else { return false; }
            }
            
        }

        private void rbCalculatingMachine_CheckedChanged(object sender, EventArgs e)
        {
            if ((bool)sender.GetType().GetProperty("Checked").GetValue(sender, null))
            {
                rbNoSign.Enabled = true;
                rbNoSign.Checked = true;
            }

            else
            {
                rbNoSign.Enabled = false;
                rbNoSign.Checked = false;
                rbHSM.Checked = true;
            }
                
        }
    }
}
