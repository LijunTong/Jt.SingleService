namespace Jt.SingleService.Data
{
    public class CodeTempParamsDto
    {
        public string CodeSchemeId { get; set; }
        public string TableName { get; set; }
        public string ClassName { get; set; }
        public List<DbFieldInfo> DbFieldInfos { get; set; }
        public List<CodeSchemeDetials> Temps { get; set; }
    }
}
