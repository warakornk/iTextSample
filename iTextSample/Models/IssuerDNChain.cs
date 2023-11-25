namespace iTextSample.Models
{
	public class IssuerDNChain
	{
		public int Index { get; set; }
		public string Issuer { get; set; }
		public string IssuerDN { get; set; }
		public string SubjectDN { get; set; }
		public string SerialNumber { get; set; }
		public DateTime? NotBefore { get; set; }
		public DateTime? EndDateTime { get; set; }
	}
}