namespace iTextSample.Models
{
	public class SimpleSignatureInfomation2
	{
		public string Name { get; set; }    // name of signer
		public string SignName { get; set; }    // email of user who sign the document
		public string SignReason { get; set; }  // reason of signing the document
		public string SignLocation { get; set; }    // location of signing the document
		public DateTime SignDate { get; set; }    // date of signing the document.
		public int Revision { get; set; }    // revision of the document
		public bool SignatureCoversWholeDocument { get; set; }    // check if the signature covers the whole document
		public bool VerifySignatureIntegrityAndAuthenticity { get; set; }    // check if the signature is valid
		public string DigestAlgorithm { get; set; }    // digest algorithm of the signature
		public string EncryptionAlgorithm { get; set; }    // encryption algorithm of the signature
		public List<IssuerDNChain> IssuerDNChains { get; set; } = new List<IssuerDNChain>();    // issuer DN chain of the certificate
	}
}