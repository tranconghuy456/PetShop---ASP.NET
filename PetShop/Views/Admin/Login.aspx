<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PetShop.Views.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pet Housh - Admin Panel</title>

    <link rel="stylesheet" href="../../Assets/Libs/bootstrap.min.css" />
    <link rel="stylesheet" href="../../Assets/Libs/remixicon.css" />
    <link rel="stylesheet" href="../../Assets/Css/Admin/Login.css" />

</head>
<body>
    <div aria-live="polite" aria-atomic="true" class="toast__box">
        <div class="toast__container"></div>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-3 col-md-2">
                <div class="login__box">
                    <div class="login__box-header">
                    <img src="../../Assets/Images/pet-logo.png" alt="Logo" />
                    <div class="col-lg-12 login__box-title">
                        ADMIN PANEL                        
                    </div>
                    </div>
                    <div class="col-lg-12 login__form">
                        <form id="loginForm" runat="server">
                            <div class="form-group">
                                <label class="form-control-label">USERNAME</label>
                                <input id="username" type="text" class="form-control" runat="server" autocomplete="off" required="required" />
                            </div>
                            <div class="form-group">
                                <label class="form-control-label">PASSWORD</label>
                                <input id="password" type="password" class="form-control" runat="server" required="required"/>
                            </div>
                            <div class="login__form-button">
                                <asp:Button ID="loginBtn" CssClass="btn btn-outline-primary" runat="server" Text="Login" OnClick="loginBtn_Click" />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="../../Assets/Libs/jquery-3.6.3.min.js"></script>

    <script type="text/javascript">
        function toastMessage(options) {
            options = {
                from: options.from || "Hệ Thống",
                to: options.to || "local",
                type: options.type || "warning",
                message: options.message || "Lỗi không xác định.",
                duration: options.duration || 3000, // thời gian hiện
                delay: (options.duration > 1000) ? options.duration - 1000 : options.duration || 1000 // thời gian callback
            };

            // icons
            const icons = {
                warning: "<i class='ri-error-warning-fill warning'></i>",
                danger: "<i class='ri-close-circle-fill danger'></i>",
                success: "<i class='ri-checkbox-circle-fill success'></i>",
                user: "<i class='ri-account-pin-circle-fill warning'></i>",
                system: "<i class='ri-cpu-fill success'></i>"
            }

            // append toast content
            $(".toast__container").append(
                `<div class="toast" role="alert" aria-live="assertive" aria-atomic="true">
            <div class="toast-header">
                ${icons[options.type]}
                <strong class="me-auto">${options.from}</strong>
                <small class="text-muted">now</small>
                <button type="button" class="btn-close btn-close-white" data-bs-dismiss="toast" aria-label="Close"></button>
            </div>
                <div class="toast-body">
                    ${options.message}
                </div>
        </div>`
            ).promise().done(() => { // append done
                var toastElList = document.querySelectorAll('.toast');
                [...toastElList].map((toastEl) => {
                    // show toast
                    new bootstrap.Toast(toastEl, {
                        delay: options.duration
                    }).show();

                    // Hide & remove
                    $(toastEl).on("hide.bs.toast", () => {
                        toastEl.remove();
                    });
                });
            });
        }
    </script>
</body>
</html>
