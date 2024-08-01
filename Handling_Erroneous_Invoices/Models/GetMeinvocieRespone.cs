using API3.SDK.Model.Parameter;
using API3.SDK.Model.SDKResult;
using System;
using System.Collections.Generic;

namespace Handling_Erroneous_Invoices.Models
{
    
    public class GetMeinvocieRespone
    {
        public string InvoiceCode { get; set; }
        public int GrantCodeStatus { get; set; }
        public string CompanyTaxCode { get; set; }
        public string TransactionID { get; set; }
        public string InvoiceName { get; set; }
        public int InvoiceType { get; set; }
        public string InvTemplateNo { get; set; }
        public string InvSeries { get; set; }
        public string InvNo { get; set; }
        public DateTime InvDate { get; set; }
        public object IsExportInvoice { get; set; }
        public object IsNonTariffAreaInvoice { get; set; }
        public object ListNo { get; set; }
        public object ListDate { get; set; }
        public string CurrencyCode { get; set; }
        public decimal? ExchangeRate { get; set; }
        public string PaymentMethodName { get; set; }
        public object ReferenceType { get; set; }
        public object StockOutLegalName { get; set; }
        public object StockOutTaxCode { get; set; }
        public object InvoiceNote { get; set; }
        public string SellerLegalName { get; set; }
        public string SellerAddress { get; set; }
        public object SellerPhoneNumber { get; set; }
        public object SellerEmail { get; set; }
        public object SellerBankAccount { get; set; }
        public object SellerBankName { get; set; }
        public object SellerFax { get; set; }
        public object SellerWebsite { get; set; }
        public string BuyerLegalName { get; set; }
        public string BuyerTaxCode { get; set; }
        public string BuyerAddress { get; set; }
        public string BuyerCode { get; set; }
        public string BuyerPhoneNumber { get; set; }
        public string BuyerEmail { get; set; }
        public string BuyerFullName { get; set; }
        public string BuyerBankAccount { get; set; }
        public string BuyerBankName { get; set; }
        public decimal TotalAmountWithoutVATOC { get; set; } = 0;
        public decimal TotalVATAmountOC { get; set; } = 0;
        public decimal TotalDiscountAmountOC { get; set; } = 0;
        public decimal TotalAmountOC { get; set; } = 0;
        public decimal TotalAmount { get; set; } = 0;
        public decimal TotalAmountWithoutVAT { get; set; } = 0;
        public decimal TotalVATAmount { get; set; } = 0;
        public decimal TotalDiscountAmount { get; set; } = 0;
        public string TotalAmountInWords { get; set; }
        public object InternalCommand { get; set; }
        public string StockOutAddress { get; set; }
        public string TransportContractCode { get; set; }
        public string ContractCode { get; set; }
        public string ContractDate { get; set; }
        public string StockOutFullName { get; set; }
        public string TransporterName { get; set; }
        public string Transport { get; set; }
        public string StockInLegalName { get; set; }
        public string StockInTaxCode { get; set; }
        public string StockInAddress { get; set; }
        public string StockInFullName { get; set; }
        public int AdjustmentType { get; set; }
        public object IsDeleted { get; set; }
        public object DeletedDate { get; set; }
        public object DeletedReason { get; set; }
        public string SourceType { get; set; }
        public object ConvertToPaperTimes { get; set; }
        public string RefID { get; set; }
        public object OrgInvoiceType { get; set; }
        public string OrgInvTemplateNo { get; set; }
        public string OrgInvSeries { get; set; }
        public string OrgInvNo { get; set; }
        public string OrgInvDate { get; set; }
        public Guid? InvoiceTemplateID { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public List<InvoiceDataDetail> InvoiceDataDetails { get; set; }
        public object ReplacementInvoice { get; set; }
        public object FeeInfo { get; set; }
        public List<TaxRateInfo> TaxRateInfo { get; set; }
        public object AdjustmentInvoice { get; set; }
        public object NotificationInfo { get; set; }
        public string OrganizationUnitID { get; set; }
        public object OrganizationUnitCode { get; set; }
        public object OrganizationUnitName { get; set; }
        public object TypeChangeInvoice { get; set; }
        public object IsTaxReduction { get; set; }
        public bool IsTaxReduction43 { get; set; }
        public object TaxReductionType { get; set; }
        public string OtherInfo { get; set; }
        public object CancelAttachmentFileName { get; set; }
        public int ErrorAnnouncementStatus { get; set; }
        public object ErrorAnnouncementID { get; set; }
        public int InvoiceProcessMethod { get; set; }
        public int ErrorInvoiceStatus { get; set; }
        public int SendToTaxStatus { get; set; }
        public bool IsInvoiceSummary { get; set; }
        public int SummaryStatus { get; set; }
        public object CancelRefNo { get; set; }
        public int InitType { get; set; }
        public object IsSendNotifyExplanation { get; set; }
        public int IssuedType { get; set; }
        public DateTime PublishedTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
