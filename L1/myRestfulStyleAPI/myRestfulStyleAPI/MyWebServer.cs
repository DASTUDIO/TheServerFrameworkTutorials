using System;
using System.Net;

// step 1
using studio.da.ServerFrameWork;


namespace myRestfulStyleAPI
{                             // step 2
    public class MyWebServer : AbstractWebServer
    {
        public override bool OnReceiveServerData(IServer _SourceServer, DataModel _data)
        {
            throw new NotImplementedException();
        }

        public override void Setup()
        {
            //throw new NotImplementedException();
        }

        public override void TearDown()
        {
            //throw new NotImplementedException();
        }

        protected override void OnConnect(HttpListenerContext _contextHandler)
        {
            //throw new NotImplementedException();
        }

        protected override void OnDisconnect(Exception e)
        {
            //throw new NotImplementedException();
        }

        // step 3
        protected override void OnResponse(HttpListenerContext _contextHandler, string subPath)
        {
            //throw new NotImplementedException();
            SendCustomHTMLContent(_contextHandler,"<script>alert(\'Hello World\');</script>");
        }

        protected override void UrlMapping()
        {
            //throw new NotImplementedException();

            AddUrlMap("email",EmailCallback);

        }


        // 我们自定义一个响应url Mapping 的 回调
        void EmailCallback(HttpListenerContext _contextHandler , string subPath)
        {
            if(getGetParameter(_contextHandler,"name") == null)            //从数据库获取email
            {
                string name = SFDataBase.QuerySingleItem<MyTable>("Name", "id=>" + subPath);

                string email = SFDataBase.QuerySingleItem<MyTable>("Email", "id=>" + subPath);

                myDataModel mdm = new myDataModel { Name = name, Email = email };

                SendCustomObjectByJson(_contextHandler,mdm);

            }
            else                          //向数据库写入email
            {
                try{
                    SFDataBase.AddItem<MyTable>(
                                                "Name=>" + getGetParameter(_contextHandler, "name"),
                                                "Email=>" + getGetParameter(_contextHandler, "email"));
                
                
                    SendCustomHTMLContent(_contextHandler, "<script>alert(\'写入成功\')</script>");
                }
                catch
                {
					SendCustomHTMLContent(_contextHandler, "<script>alert(\'写入失败\')</script>");   
                }
            }
        }


    }


    public class myDataModel
    {
        public string Name;

        public string Email;

    }


}
