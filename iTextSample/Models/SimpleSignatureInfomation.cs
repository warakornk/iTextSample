namespace iTextSample.Models
{
	public class SimpleSignatureInfomation
	{
		public string SignName { get; set; }    // email of user who sign the document
		public string SignReason { get; set; }  // reason of signing the document
		public string SignLocation { get; set; }    // location of signing the document
		public DateTime SignDate { get; set; }    // date of signing the document. This date can't convert to datetime directly.
	}
}