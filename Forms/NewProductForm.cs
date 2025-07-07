using System.ComponentModel;

public class NewProductForm : Form
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Name
    {
        get => tbName.Text;
        set => tbName.Text = value;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public decimal Price
    {
        get => decimal.Parse(tbPrice.Text);
        set => tbPrice.Text = value.ToString();
    }

    private TextBox tbName;
    private TextBox tbPrice;

    public NewProductForm()
    {
        tbName = new TextBox { Width = 200 };
        tbPrice = new TextBox { Width = 200 };
        Width = 400;
        Height = 400;
        Text = "Editar Produto";
        var btSave = new Button { 
            Text = "Salvar",
            Height = 40, Width = 80
        };
        var btExit = new Button { 
            Text = "Cancelar", 
            Height = 40, Width = 80 
        };

        btExit.Click += (o, e) =>
        {
            DialogResult = DialogResult.Cancel;
            Close();
        };

        btSave.Click += Insert;
        
        var layout = new FlowLayoutPanel {
            Dock = DockStyle.Fill,
            Padding = new Padding(20),
            Controls = {
                new FlowLayoutPanel {
                    FlowDirection = FlowDirection.LeftToRight,
                    Width = 400, Height = 40,
                    Controls = {
                        new Label {
                            Text = "Nome",
                        },
                        tbName
                    }
                },
                new FlowLayoutPanel {
                    FlowDirection = FlowDirection.LeftToRight,
                    Width = 400, Height = 40,
                    Controls = {
                        new Label {
                            Text = "Preço",
                        },
                        tbPrice
                    }
                },
                new FlowLayoutPanel {
                    FlowDirection = FlowDirection.RightToLeft,
                    Width = 300, Height = 120,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    Controls = {
                        btSave, btExit
                    }
                }
            }
        };

        Controls.AddRange(layout);
    }

    async void Insert(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;

        // TODO

        Close();
    }
}