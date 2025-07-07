using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;

public class LoginForm : Form
{
    async Task OnClick()
    {
        var username = tbUsername.Text;
        var password = tbPassword.Text;

        var database = new Database();
        var db = await database.Create();

        var query =
            from u in db.UserDatas
            where username == u.Username && password == u.Pass
            select u;

        var findUser = await query.FirstOrDefaultAsync();

        if (findUser == null)
        {
            MessageBox.Show("Senha ou usuário inválido.");
            return;
        }

        var userId = findUser.ID;
        var productForm = new ProductForm(userId);
        productForm.Show();
        Hide();
    }

    TextBox tbUsername;
    TextBox tbPassword;
    public LoginForm()
    {
        Text = "Login";
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Width = 400;
        Height = 300;
        FormClosing += (o, e) => Application.Exit();

        tbUsername = new TextBox {
            Width = 200,
            PlaceholderText = "digite seu usuário..."
        };
        tbPassword = new TextBox {
            Width = 200,
            UseSystemPasswordChar = true,
            PlaceholderText = "digite sua senha..."
        };

        var btLogin = new Button {
            Width = 80, Height = 40,
            Text = "Logar"
        };

        btLogin.Click += async (o, e) => await OnClick();

        Controls.Add(new FlowLayoutPanel {
            Dock = DockStyle.Fill,
            Padding = new Padding(40),
            Controls = {
                new FlowLayoutPanel {
                    FlowDirection = FlowDirection.LeftToRight,
                    Width = 400, Height = 40,
                    Controls = {
                        new Label {
                            Text = "usuário",
                        },
                        tbUsername
                    }
                },
                new FlowLayoutPanel {
                    FlowDirection = FlowDirection.LeftToRight,
                    Width = 400, Height = 40,
                    Controls = {
                        new Label {
                            Text = "senha",
                        },
                        tbPassword
                    }
                },
                new FlowLayoutPanel {
                    FlowDirection = FlowDirection.RightToLeft,
                    Width = 300, Height = 60,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    Controls = {
                        btLogin
                    }
                }
            }
        });
    }
}