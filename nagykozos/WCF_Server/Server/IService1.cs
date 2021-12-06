using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Server
{
        [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]

        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/UpdateUserWeb?uid={uid}&id={id}&bNev={bNev}&jelszo={jelszo}&fNev={fNev}&jog={jog}&aktiv={aktiv}"
            )]
        string UpdateUserWeb(string uid, int id, string bNev, string jelszo, string fNev, int jog, int aktiv);    //UPDATE

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]

        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest
            )]
        string UpdateUser(string uid, Felhasznalo user);    //UPDATE

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]

        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/DeleteUserId?uid={uid}&id={id}"
            )]
        string DeleteUserId(string uid, int id);    //DELETE

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]

        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/DeleteUser?uid={uid}&bNev={bNev}"
            )]
        string DeleteUser(string uid, string bNev);    //DELETE

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]

        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/InsertUserWeb?uid={uid}&bNev={bNev}&jelszo={jelszo}&fNev={fNev}&jog={jog}&aktiv={aktiv}"
            )]
        string InsertUserWeb(string uid, string bNev, string jelszo, string fNev, int jog, int aktiv);    //INSERT

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]

        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest
            )]
        string InsertUser(string uid, Felhasznalo user);    //INSERT

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]

        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/FelhasznaloiLista?uid={uid}"
            )]
        List<Felhasznalo> FelhasznaloiLista(string uid);    //SELECT

        [OperationContract]
        [WebInvoke(Method ="POST",
            RequestFormat =WebMessageFormat.Json,
            ResponseFormat =WebMessageFormat.Json,
            BodyStyle =WebMessageBodyStyle.WrappedRequest,
            UriTemplate ="/Login?bNev={bNev}&jelszo={jelszo}"
            )]
        string Login(string bNev, string jelszo);
        [FaultContract(typeof(ServiceFault))]

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/Logout?uid={uid}"
            )]
        string Logout(string uid);

    }

    [DataContract]

    public class Record
    {
        int? id = null;

        [DataMember]

        public int? Id
        {
            get { return id; }
            set { id = value; }
        }

        protected Record()
        {

        }

        protected Record(int? id)
        {
            if (id==null)
            {
                throw new ArgumentNullException();
            }
            this.id = id;
        }
    }

    [DataContract]

    public class Felhasznalo:Record
    {
        string bNev, jelszo, fNev = null;
        int jog, aktiv;

        [DataMember]

        public string BNev
        {
            get { return bNev; }
            set { bNev = value; }
        }

        [DataMember]

        public string Jelszo
        {
            get { return jelszo; }
            set { jelszo = value; }
        }

        [DataMember]
        public string FNev
        {
            get { return fNev; }
            set { fNev = value; }
        }

        [DataMember]

        public int Jog
        {
            get { return jog; }
            set { jog = value; }
        }

        [DataMember]

        public int Aktiv
        {
            get { return aktiv; }
            set { aktiv = value; }
        }

        public Felhasznalo(string bNev,string jelszo,string fNev,int jog,int aktiv)
        {
            this.BNev = bNev;
            this.Jelszo = jelszo;
            this.FNev = fNev;
            this.Jog = jog;
            this.Aktiv = aktiv;
        }

        public Felhasznalo()
        {

        }
    }

    [DataContract]

    public class ServiceFault
    {
        [DataMember]

        public string Message { get; set; }

        [DataMember]

        public string Details { get; set; }
    }
}
