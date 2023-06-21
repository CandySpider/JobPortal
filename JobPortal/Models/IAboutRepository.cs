namespace JobPortal.Models
{
    public interface IAboutRepository
    {
        void InputText (string text1, string text2);
        string GetText1();
        string GetText2();


    }
}
