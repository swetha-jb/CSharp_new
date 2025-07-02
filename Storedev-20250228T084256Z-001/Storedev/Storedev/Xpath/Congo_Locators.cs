using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storedev.Xpath
{
    public static class Congo_Locators
    {
        public static By Addtocart => By.XPath("//button[@data-pid='MC327BL-100PAS']");
        public static By click_oncart => By.XPath("//*[@id='icon-wrapper']/div[4]/div[1]/div/div/a/img");
        public static By membership => By.XPath("//label[@for='1 Year Art Membership']");
        public static By checkout => By.XPath("(//a[@role='button'])[4]");
        public static By fill_firstname => By.XPath("//input[@id='ip_firstName']");
        public static By fill_lastname => By.XPath("//input[@id='ip_lastName']");
        public static By fill_emailfield => By.XPath("//input[@autocomplete='email']");
        public static By fill_password => By.XPath("//input[@id='ip_pwdSignup']");
        public static By fill_cinfirmpwd => By.XPath("//input[@id='ip_cnfPwd']");
        public static By click_onbutton => By.XPath("//button[@id='signupBtn_i']");
        public static By cickcheckbox_fr => By.XPath("//input[@id='mat-mdc-checkbox-2-input']");
        public static By fillpwd => By.XPath("//input[@id='mat-input-9']");
        public static By click_signinbutton => By.XPath("//div[@id='Login-btn']");
        public static By click_loginwithonetime => By.XPath("//a[@id='otp_link']");
        //forgot password
        public static By clickonforgotbutton => By.XPath("//a[@id='fgt_link']");
        public static By fill_email => By.XPath("//input[@type='email']");
        public static By click_on_button => By.XPath("//button[@id='btn_fgtCode']");
        public static By Eneter_verificationcode => By.XPath("(//input[@type='text'])[1]");
        public static By Eneter_Newpassword => By.XPath("//input[@autocomplete='new-password']");
        public static By Eneter_cnfpassword => By.XPath("//input[@formcontrolname='cnfPassword']");
        public static By click_on_submittbutton => By.XPath("//button[@id='btn_fgtSubmit']");

        //Login with one-time-password ==============================
        public static By click_on_onetimepass => By.XPath("//a[@id='otp_link']");
        public static By onetime_email => By.XPath("//input[@type='email']");
        public static By click_ontimebutton => By.XPath("//button[@id='getcode-btn']");
        public static By fill_otp => By.XPath("//input[@id='ip_otp']");
        public static By click_onlogin => By.XPath("//span[text()='Log In']");
    }
}
