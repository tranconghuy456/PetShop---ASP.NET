using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ToastMessage({ message: " + opt.message + "})", true);


namespace PetShop.Models
    
{
    public class ToastMessage
    {
        string strFrom, strTo, strType, strMessage;
        float fDuration;
        public string values;

        public ToastMessage(string from, string to, string type, string message, float duration)
        {
            strFrom = from;
            strTo = to;
            strType = type;
            strMessage = message;
            fDuration = duration;
        }

        public ToastMessage()
        {
            strFrom = "System";
            strTo = "local";
            strType = "warning";
            strMessage = "BadError";
            fDuration = 3000;
        }

        public string options()
        {
            //return (
            //"window.onload = function() { toastMessage({ from:" + strFrom + "," +
            //"to:" + strTo + "," +
            //"type:" + strType + "," +
            //"message:" + strMessage + "," +
            //"duration:" + fDuration + ")}" + "}");
            //return (
            //  "window.onload = function() {toastMessage({" +
            //"from:" + strFrom +
            //", to:" + strTo +
            //", type:" + strType +
            //", message:" + strMessage +
            //", duration:" + fDuration + 
            //"})}");
            return (
                "window.onload = function() {toastMessage()}"
            );
        }
    }
}