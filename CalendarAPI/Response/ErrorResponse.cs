

namespace CalendarAPI.Response
{
    public class ErrorResponse
    {

        public const string MAX_ERROR = "1 dakika içerisinde en fazla 10 istekte bulunabilirsiniz";

        public const string IS_GREATER_ERROR = "Başlangıç tarihi bitiş tarihinden büyük olamaz.";

        public const string IS_DATE_TYPE = "Girdiğiniz veriler tarih formatında değildir.";

        public const string IS_DATE_BETWEEN = "Karşılaştıracağınız tarihler 1-Ocak 1901 ve 31-Aralık 2000 arasında olmalıdır.";

        public const string INTERVAL_ERROR = "İsteğinizde problem oluştu";

        public const string ERROR_REQUEST = "Hatalı istek yaptınız";

    }
}
