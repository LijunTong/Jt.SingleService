namespace Jt.SingleService.Data
{
    public class CodeGenSchemeDto
    {
        public CodeGenScheme CodeGenScheme { get; set; }
        public List<CodeTempDto> Temps { get; set; }

        public string UserId { get; set; }
    }
}
