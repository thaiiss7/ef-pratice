public class LoginForm : Form
{
    TextBox loginText;
    TextBox passText;
    Button loginButton;
    public LoginForm()
    {
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Width = 400;
        Height = 300;

        loginText = new TextBox {
            Width = 200,
            PlaceholderText = "digite seu usuário..."
        };
        passText = new TextBox {
            Width = 200,
            UseSystemPasswordChar = true,
            PlaceholderText = "digite sua senha..."
        };

        loginButton = new Button {
            Width = 80, Height = 40,
            Text = "Logar"
        };

        loginButton.Click += OnClick;

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
                        loginText
                    }
                },
                new FlowLayoutPanel {
                    FlowDirection = FlowDirection.LeftToRight,
                    Width = 400, Height = 40,
                    Controls = {
                        new Label {
                            Text = "senha",
                        },
                        passText
                    }
                },
                new FlowLayoutPanel {
                    FlowDirection = FlowDirection.RightToLeft,
                    Width = 300, Height = 60,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    Controls = {
                        loginButton
                    }
                }
            }
        });
    }

    async void OnClick(object sender, EventArgs e)
    {

    }
}