namespace rainfalls.Base.Class
{
    public class CMessage
    {
        public const int WM = 0x500;
        public const int WM_TIMER = WM + 1;
        public const int WM_ONSHOW_REGFORM = WM + 2;
        public const int WM_ONINIT_REGFORM = WM + 3;
        public const int WM_ONSHOW_OPENNOTIFYCONTROL = WM + 4;
        public const int WM_ONHIDDEN_OPENNOTIFYCONTROL = WM + 5;
        public const int WM_ONADD_PERSON = WM + 6;
        public const int WM_ONMODIFY_PERSON = WM + 7;
        public const int WM_ONREFRESH_SITEGRIDVIEW = WM + 8;
        public const int WM_ONREFRESH_SECTIONGRIDVIEW = WM + 9;
        public const int WM_ONREFRESH_INSPECTORVIEW = WM + 10;
        public const int WM_ONREFRESH_RAINMAP = WM + 11;
    }
}
