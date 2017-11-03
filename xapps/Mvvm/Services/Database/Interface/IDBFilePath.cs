namespace xapps.DatabaseHelper.Interface
{
    /**
     * DB 물리파일 위치 가져오기
     * Interface
     * by 한수현.
     */
    public interface IDBFilePath
    {
        string GetLocalFilePath(string filename);
    }
}
