using System;

namespace CommandModule
{
    public class ComandModule : EventArgs
    {
        private string _responseText;
        public bool IsOpenTextEditor = false;
        public bool IsOpenFileManager = false;
        public bool EnterText = false;
        public bool Redact = false;
        public ProgramCommand PCom = ProgramCommand.None;
        public MenuCommand MCommand = MenuCommand.None;
        public string Text;


        public ComandModule()
        {

        }

        public void GetResponse(string str)
        {
            _responseText = str;
            ParseResponse();
        }

        //parse responze
        private void ParseResponse()
        {
            if (_responseText.Contains("���������"))
            {
                if (_responseText.Contains("�������") && _responseText.Contains("���������") && _responseText.Contains("��������"))
                {
                    PCom = ProgramCommand.OpenTxt;
                }
                if (_responseText.Contains("�������"))
                {
                    PCom = ProgramCommand.Exit;
                }
                if (_responseText.Contains("������������"))
                {
                    PCom = ProgramCommand.Change;
                }
                if (_responseText.Contains("�������") && _responseText.Contains("��������") && _responseText.Contains("��������"))
                {
                    PCom = ProgramCommand.OpenFm;
                }
                if (_responseText.Contains("�������") && _responseText.Contains("��������") && _responseText.Contains("��������"))
                {
                    PCom = ProgramCommand.ExitFm;
                }
            }
            else 
            {
                if (_responseText.Contains("���������") && _responseText.Contains("�����") && _responseText.Contains("������"))
                    MCommand = MenuCommand.NotEnterTxt;
                else if (IsOpenTextEditor == true && EnterText==true)
                {
                    Text = _responseText;
                }
                else if (_responseText.Contains("�������"))
                    MCommand = MenuCommand.Create;
                else if (_responseText.Contains("���������"))
                    MCommand = MenuCommand.Save;
                else if (_responseText.Contains("���������") && _responseText.Contains("���"))
                    MCommand = MenuCommand.SaveAs;
                else if (_responseText.Contains("������"))
                    MCommand = MenuCommand.Print;
                else if (_responseText.Contains("��������"))
                    MCommand = MenuCommand.PreView;
                else if ( _responseText.Contains("�����") && _responseText.Contains("������"))
                    MCommand = MenuCommand.EnterTxt;
                
            }

        }
        public void ClearAllCommands()
        {
            PCom = ProgramCommand.None;
            MCommand = MenuCommand.None;
            Text = "";
        }


    }
}