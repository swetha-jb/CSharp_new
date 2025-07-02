using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storedev.Xpath
{
    public static class Locators
    {


        //Create Account Xpath  =======================================================
        public static By Create_Account_button => By.XPath("//a[@class='btn btn-primary btn-myaccount']");
        public static By EmailInput => By.XPath("//input[@formcontrolname='email']");
        public static By ConfirmEmailInput => By.XPath("//input[@formcontrolname='cnfEmail']");
        public static By FirstNameInput => By.XPath("//input[@formcontrolname='firstName']");
        public static By LastNameInput => By.XPath("//input[@formcontrolname='lastName']");

        public static By PasswordInput => By.XPath("//input[@formcontrolname='password']");
        public static By ConfirmPasswordInput => By.XPath("//input[@formcontrolname='cnfPassword']");
        public static By TermsCheckbox => By.XPath("//input[@type='checkbox']");
        public static By submitt_button => By.XPath("//button[@form='signupForm']");
        public static By popupMessage => By.XPath("//*[@id='successBlock']/div");
        public static By submitt_button_1 => By.Id("Login-btn");
        public static By logovalidation => By.XPath("//img[@alt='Netgear']");
        public static By logout_button_1 => By.XPath("//a[@class='btn btn-outline-primary btn-logout']");

        // Manage Profile ============================================================

        public static By click_on_icon => By.XPath("//img[@class='nav-item nav_icon image-dark account-icon']");
        public static By click_on_manage_profile => By.XPath("//a[text()='Manage Profile']");
        public static By click_on_cancel => By.XPath("//span[text()='Cancel']");
        public static By click_on_login_setting => By.XPath("//span[text()='Login Settings']");

        //=============================================================================================

        public static By click_on_two_step_verification => By.XPath("//span[text()='Two-Step Verification']");
        public static By click_on_toggle_button => By.XPath("//button[@id='mat-mdc-slide-toggle-1-button']");
        public static By click_on_continue_button => By.XPath("//button[text()='Continue']");
        //Login with 2MFA Xpath ===========================================

        public static By click_on_mfabox => By.XPath(" //input[@type='tel'][1]");
        public static By continue_button => By.XPath("//span[text()='Continue']");
        public static By donot_trust => By.XPath("//*[@id='scroll-style']/div[2]/div/div[2]/button");

        //Changepassword ================================================================
        public static By click_on_changepass => By.XPath("//span[text()='Change Password']");
        public static By fill_old_pass => By.XPath("//input[@id='mat-input-0']");
        public static By fill_pass => By.XPath("//input[@id='mat-input-1']");
        public static By fill_cnfpass => By.XPath("//input[@id='mat-input-2']");
        public static By submit => By.XPath("//span[text()='Submit']");
        public static By changepassword_popupmessage => By.XPath("//*[@id='successBlock']/div");

        // Changeemail ======================================================================

        public static By click_on_changeemail => By.XPath("//span[text()='Change Email']");
        public static By fill_new_email => By.XPath("//input[@formcontrolname='email']");
        public static By fill_cnf_new_email => By.XPath("//input[@formcontrolname='cnfEmail']");
        public static By fill_current_pass => By.XPath("//input[@formcontrolname='password']");
        public static By fill_verification_code => By.XPath("//input[@formcontrolname='otpOnEmail']");
        public static By changemailpop_message => By.XPath("//*[@id='successBlock']/div");



        //purchase Xpath =====================================================

        public static By Addtocart => By.XPath("//button[@data-pid='MC327BL-100PAS']");

        public static By click_oncart => By.XPath("//*[@id='icon-wrapper']/div[4]/div[1]/div/div/a/img");
        public static By membership => By.XPath("//label[@for='1 Year Art Membership']");
        public static By checkout => By.XPath("(//a[@role='button'])[4]");

        //Payment method =========================================================

        public static By fill_fname => By.XPath("//input[@id='shippingFirstName']");
        public static By fill_lname => By.XPath("//input[@id='shippingLastName']");
        public static By Street_address => By.XPath("//input[@id='shippingAddressOne']");
        public static By city => By.XPath("//input[@id='shippingAddressCity']");
        public static By state => By.XPath("//select[@id='shippingState']");

        public static By Zip_code => By.XPath("//input[@id='shippingZipCode']");
        public static By phone_no => By.XPath("//input[@id='shippingPhoneNumber']");
        public static By payment_submitt_button => By.XPath("//*[@id='checkout-main']/div/div[1]/div[6]/div/div/button[1]");
        public static By org_address_button => By.XPath("//button[@id='interaction--use-original']");
        public static By fill_cardno => By.XPath("//input[@inputmode='numeric']");
        public static By fll_card_exp_date => By.XPath("//input[@id='cardExpiry']");
        public static By fill_cvv => By.XPath("//input[@id='securityCode']");
        public static By clck_submit_paymentbutton => By.XPath("//button[@value='submit-payment']");










        //Forgot Password Xpath ===============================

        public static By forgot_password => By.XPath("//a[@id='fgt-showFPTL']");
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


        //Cognito xpath =============================================================
        public static By fill_firstname => By.XPath("//input[@id='ip_firstName']");
        public static By fill_lastname => By.XPath("//input[@id='ip_lastName']");
        public static By fill_emailfield => By.XPath("//input[@autocomplete='email']");
        public static By fill_password => By.XPath("//input[@id='ip_pwdSignup']");
        public static By fill_cinfirmpwd => By.XPath("//input[@id='ip_cnfPwd']");
        public static By click_onbutton => By.XPath("//button[@id='signupBtn_i']");
        public static By cickcheckbox_fr => By.XPath("//input[@id='mat-mdc-checkbox-2-input']");
    }



    
}
