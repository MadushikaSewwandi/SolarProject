namespace UmbracoSolarProject1
{
	public class EmailTemplates
	{
		public const string EMAIL_HEAD = @"
                <html><head>
                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">
                <title>Initial Contact</title>
                <style>
                    @media only screen and(max-width: 620px) {
                        table.body h1 {
                            font-size: 28px !important;
                            margin-bottom: 10px !important;
                        }

                        table.body p,
                        table.body ul,
                        table.body ol,
                        table.body td,
                        table.body span,
                        table.body a {
                            font-size: 16px !important;
                        }

                        table.body .wrapper,
                        table.body .article {
                            padding: 10px !important;
                        }

                        table.body .content {
                            padding: 0 !important;
                        }

                        table.body .container {
                            padding: 0 !important;
                            width: 100% !important;
                        }

                        table.body .main {
                            border-left-width: 0 !important;
                            border-radius: 0 !important;
                            border-right-width: 0 !important;
                        }

                        table.body .btn table {
                            width: 100% !important;
                        }

                        table.body .btn a {
                            width: 100% !important;
                        }

                        table.body .img-responsive {
                            height: auto !important;
                            max-width: 100% !important;
                            width: auto !important;
                        }
                    }
                    @media all {
                        .ExternalClass {
                            width: 100%;
                        }

                        .ExternalClass,
                        .ExternalClass p,
                        .ExternalClass span,
                        .ExternalClass font,
                        .ExternalClass td,
                        .ExternalClass div {
                            line-height: 100%;
                        }

                        .apple-link a {
                            color: inherit !important;
                            font-family: inherit !important;
                            font-size: inherit !important;
                            font-weight: inherit !important;
                            line-height: inherit !important;
                            text-decoration: none !important;
                        }

                        #MessageViewBody a {
                            color: inherit;
                            text-decoration: none;
                            font-size: inherit;
                            font-family: inherit;
                            font-weight: inherit;
                            line-height: inherit;
                        }

                        .btn-primary table td:hover {
                            background-color: #34495e !important;
                        }

                        .btn-primary a:hover {
                            background-color: #34495e !important;
                            border-color: #34495e !important;
                        }
                    }
                </style>
                <link rel=""preconnect"" href=""https://fonts.googleapis.com"">
                <link rel=""preconnect"" href=""https://fonts.gstatic.com"" crossorigin="">
                <link href=""https://fonts.googleapis.com/css2?family=Roboto:wght@100;300;400&amp;display=swap"" rel=""stylesheet"">
            </head>
            <body style=""background-color: #f6f6f6; font-family: Roboto, sans-serif; -webkit-font-smoothing: antialiased; font-size: 16px; line-height: 1.4; margin: 0; padding: 0; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;"">
                <span class=""preheader"" style=""color: transparent; display: none; height: 0; max-height: 0; max-width: 0; opacity: 0; overflow: hidden; mso-hide: all; visibility: hidden; width: 0;""></span>
                <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""body"" style=""border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f6f6f6; width: 100%;"" width=""100%"" bgcolor=""#f6f6f6"">
                    <tbody><tr>
                        <td style=""font-family: Roboto, sans-serif; font-size: 16px; vertical-align: top;"" valign=""top"">&nbsp;</td>
                        <td class=""container"" style=""font-family: Roboto, sans-serif; font-size: 16px; vertical-align: top; display: block; max-width: 580px; padding: 10px; width: 580px; margin: 0 auto;"" width=""580"" valign=""top"">
                            <div class=""content"" style=""box-sizing: border-box; display: block; margin: 0 auto; max-width: 580px; padding: 10px;"">
                                <!-- START CENTERED WHITE CONTAINER -->
                                <table role=""presentation"" class=""main"" style=""border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; background: #ffffff; border-radius: 3px; width: 100%;"" width=""100%"">

                                    <!-- START MAIN CONTENT AREA -->
                                    <tbody><tr>
                                        <td class=""wrapper"" style=""font-family: Roboto, sans-serif; font-size: 16px; justify-content: center; box-sizing: border-box; padding: 20px;"">
                                            <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;"" width=""100%"">
                                                <tbody><tr>
                                                    <td style=""font-family:Roboto,sans-serif;font-size:16px;vertical-align:top; display: flex; justify-content: center;"" valign=""top"">
                                                      
                                                    </td>
                                                </tr>
                                            </tbody></table>
                                        </td>
                                    </tr>

                                    <!-- END MAIN CONTENT AREA -->
                                </tbody></table>
                                <!-- START CENTERED WHITE CONTAINER -->
                                <table role=""presentation"" class=""main"" style=""border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; background: #ffffff; border-radius: 3px; width: 100%;"" width=""100%"">

                                    <tbody><tr>
                                        <td class=""wrapper"" style=""font-family: Roboto, sans-serif; font-size: 16px; vertical-align: top; box-sizing: border-box; padding: 20px;"" valign=""top"">
                                            <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;"" width=""100%"">
                                                <tbody><tr>
                                                    <td style=""font-family: Roboto, sans-serif; font-size: 16px; vertical-align: top;"" valign=""top"">
                                                        <!-- START MAIN CONTENT AREA -->";

		public const string EMAIL_TAIL = @"<p style=""letter-spacing:1px;font-family: Roboto, sans-serif; font-size: 16px; font-weight: normal; margin: 0; margin-bottom: 15px;""><br>The <b>X-Solar</b> Team<br>
Xsolar.com</p>
                                         
                                        <br>
                       
                               
                                <div style=""text-align: center;"">
                                <p style=""letter-spacing:1px;font-family: Roboto, sans-serif; font-size: 16px; font-weight: normal; margin: 0; margin-bottom: 15px;"">

                                      <small style = ""font-size: 12px; color: #058573; font-style: italic;"" > <img src=""{{webUrl}}/assets/euulo-heart.png"" style=""width: 12px; height:auto; margin-right: 5px;"">  </small>
                                </p>
                               
                                </div>
                               

                                        </p>
                                                    <!-- END MAIN CONTENT AREA -->
                                                    </td>
                                                </tr>
                                            </tbody></table>
                                        </td>
                                    </tr>

                                </tbody></table>
                                <!-- END CENTERED WHITE CONTAINER -->

                                <!-- START FOOTER -->
                                <div class=""footer"" style=""clear: both; margin-top: 10px; text-align: center; width: 100%;"">
                                    <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;"" width=""100%"">
                                        <tbody><tr>
                                            <td class=""content-block"" style=""letter-spacing:1px;font-family: Roboto, sans-serif; vertical-align: top; padding-bottom: 10px; padding-top: 10px; color: #999999; font-size: 12px; text-align: center;"" valign=""top"" align=""center"">
                                                <br>
                                                <a href=""https://www.facebook.com/euulophototribute"" target=""_blank""><img src=""{{webUrl}}/assets/facebook-circle.png"" alt=""""></a>
                                                <a href=""https://www.instagram.com/euulo_phototributes"" target=""_blank""><img src=""{{webUrl}}/assets/instagram-circle.png"" alt=""""></a>
                                                <a href=""https://www.linkedin.com/company/euulo/"" target=""_blank""><img src=""{{webUrl}}/assets/linkedin-circle.png"" alt=""""></a>
                                            </td>
                                        </tr>
                                        
                                    </tbody></table>
                                </div>
                                <!-- END FOOTER -->

                            </div>
                        </td>
                        <td style=""font-family: Roboto, sans-serif; font-size: 16px; vertical-align: top;"" valign=""top"">&nbsp;</td>
                    </tr>
                </tbody></table>
        </body></html>";

		public const string EMAIL2_TAIL = @"<p style=""letter-spacing:1px;font-family: Roboto, sans-serif; font-size: 16px; font-weight: normal; margin: 0; margin-bottom: 15px;""><br>The <b>X-Solar</b> Team<br>
x-solar.com</p>
                                         
                                        <br>
                       <div style=""text-align: center;"">
                                <p style=""letter-spacing:1px;font-family: Roboto, sans-serif; font-size: 16px; font-weight: normal; margin: 0; margin-bottom: 15px;"">

                                      <small style = ""font-size: 12px; color: #058573; font-style: italic;"" > <img src=""{{webUrl}}/assets/euulo-heart.png"" style=""width: 12px; height:auto;  margin-right: 5px;"">  </small>
                                </p>
                               
                                </div>

                                        </p>
                                                    <!-- END MAIN CONTENT AREA -->
                                                    </td>
                                                </tr>
                                            </tbody></table>
                                        </td>
                                    </tr>

                                </tbody></table>
                                <!-- END CENTERED WHITE CONTAINER -->

                                <!-- START FOOTER -->
                                <div class=""footer"" style=""clear: both; margin-top: 10px; text-align: center; width: 100%;"">
                                    <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;"" width=""100%"">
                                        <tbody>
                                        <tr>
                                            <td class=""content-block powered-by"" style=""font-family: Helvetica, Arial, sans-serif; vertical-align: top; padding-bottom: 10px; padding-top: 10px; color: #000000;letter-spacing:1px; font-size: 12px; text-align: center;"" valign=""top"" align=""center"">
                                                COPYRIGHT &#169;
                                                <a href=""http://euulo.com"" style=""letter-spacing:1px;color: #000000; font-size: 12px; text-align: center; text-decoration: none;"">EUULO</a> LIMITED 2023
                                            </td>
                                        </tr>
                                    </tbody></table>
                                </div>
                                <!-- END FOOTER -->

                            </div>
                        </td>
                        <td style=""font-family: Roboto, sans-serif; font-size: 16px; vertical-align: top;"" valign=""top"">&nbsp;</td>
                    </tr>
                </tbody></table>
        </body></html>";
		
		public const string SA_ALERT_NEW_CONTACT_FORM_SUBMISSION = EMAIL_HEAD +
			@"
                <p style=""letter-spacing:1px;font-family: Roboto, sans-serif; font-size: 16px; font-weight: 500; margin: 0; margin-bottom: 15px;"">Hi {{user}},</p>
                <p style=""letter-spacing:1px;font-family: Roboto, sans-serif; font-size: 16px; font-weight: 500; margin: 0; margin-bottom: 15px;"">
                A new contact form submission has been received from : <br>
                </p>
                <p style = ""letter-spacing:1px;font-family: Roboto, sans-serif; font-size: 16px; font-weight: normal; margin: 0; margin-bottom: 15px;"" >
                Email : {{email}}
                <p style = ""letter-spacing:1px;font-family: Roboto, sans-serif; font-size: 16px; font-weight: normal; margin: 0; margin-bottom: 15px;"" >
                Subject : {{subject}}
                </p>
                <p style = ""letter-spacing:1px;font-family: Roboto, sans-serif; font-size: 16px; font-weight: normal; margin: 0; margin-bottom: 15px;"" >
                Message : {{message}}
                </p>
            " + EMAIL_TAIL;

		public const string SUCCESSFUL_FUNERAL_DIRECTOR_REGISTRATION = EMAIL_HEAD +
			@"
            <p style=""letter-spacing:1px;font-family: 'Helvetica', Arial, sans-serif; font-size: 16px; font-weight: 500; color: #000000; margin: 0; margin-bottom: 15px;"">Hi {{user}},</p>
            <p style=""letter-spacing:1px;font-family: 'Helvetica', Arial, sans-serif; font-size: 16px; font-weight: normal; color: #000000; margin: 0; margin-bottom: 15px;"">
            Thank you for your registering with X-Solar. As we work exclusively with the funeral industry you won’t be able to  access our software or pricing until we’ve verified your account.
            </p>
            <p style=""letter-spacing:1px;font-family: 'Helvetica', Arial, sans-serif; font-size: 16px; font-weight: normal; margin: 0; color: #000000; margin-bottom: 15px;"">
            We will review your account within 48 hours. Thank you for your patience.</p>
           <p style=""letter-spacing:1px;font-family: 'Helvetica', Arial, sans-serif; font-size: 16px; font-weight: normal; margin: 0; color: #000000; margin-bottom: 15px;"">Warm regards,<br>
            " + EMAIL_TAIL;

        public const string RESET_PASSWORD = EMAIL_HEAD +
            @"
                <p style=""letter-spacing:1px;font-family:  'Helvetica', Arial, sans-serif; font-size: 16px; color: #000000; font-weight: normal; margin: 0; margin-bottom: 15px;"">Hi {{user}},</p>
                <p style=""letter-spacing:1px;font-family:  'Helvetica', Arial, sans-serif; font-size: 16px; color: #000000; font-weight: normal; margin: 0; margin-bottom: 15px;"">
                            We have received a request to reset the password for your account. Please follow the link below to reset your password.
                </p>
                <a href=""{{url}}"">Click this link to reset your password</a><br><br>
                <p style=""letter-spacing:1px;font-family:  'Helvetica', Arial, sans-serif; font-size: 16px; font-weight: normal; color: #000000; margin: 0; margin-bottom: 15px;"">If you did not request a password reset, please disregard this message.</p>
            " + EMAIL_TAIL;


    }
}
