namespace xapps
{
    public interface IToastAlert
    {
        void showToast(string msg);
        void showToast(string msg, bool LongToast);
    }
}
