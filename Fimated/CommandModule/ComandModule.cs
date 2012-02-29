using System;

namespace CommandModule
{
    public class ComandModule : EventArgs
    {
        private string _responseText;
        public bool IsOpenTextEditor = false;
        public bool IsOpenFileManager = false;
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
            }
            else if(_responseText.Contains("�������"))
            {
                if (_responseText.Contains("�������"))
                    MCommand = MenuCommand.Create;
            }


            else
            {
                if (IsOpenTextEditor == true)
                {
                    Text = _responseText;
                }
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