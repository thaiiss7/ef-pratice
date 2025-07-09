using Microsoft.EntityFrameworkCore;

public class SalesForm : Form
{
    async Task Buy(int productId, int userId)
    {
        var database = new Database();
        var db = await database.Create();

        var sale = new Sale
        {
            ProductItemID = productId,
            UserDataID = userId,
            BuyDate = DateTime.Now
        };

        db.Add(sale);
        await db.SaveChangesAsync();

        MessageBox.Show("Compra realizada com sucesso!");
    }

    async Task LoadData(int productId)
    {
        Clear();

        // var database = new Database();
        // var db = await database.Create();

        // var sales = await db.Sales.ToListAsync();
        // foreach (var item in sales)
        //     Add(item.ProductItem.Name, item.UserData.Username, item.ID);

        // Add("bico", "trevis", "07/07/2025 10:55");
        // Add("bico", "cristian", "07/07/2025 11:05");
    }

    DataGridView table;
    public SalesForm(int userId, int productId)
    {
        Text = "Compras";
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Width = 800;
        Height = 800;
        Shown += async (o, e) =>
            await LoadData(productId);

        table = new DataGridView {
            Dock = DockStyle.Fill,
            AllowDrop = false,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AllowUserToOrderColumns = false
        };
        table.Columns.Add(new DataGridViewColumn {
            HeaderText = "Produto",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        });
        table.Columns.Add(new DataGridViewColumn {
            HeaderText = "Comprador",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        });
        table.Columns.Add(new DataGridViewColumn {
            HeaderText = "Data/Hora",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        });

        var btBuy = new ToolStripButton {
            Text = "Comprar",
        };

        var btExit = new ToolStripButton {
            Text = "Voltar",
        };
        btExit.Click += (o, e) => {
            Hide();
            var login = new ProductForm(userId);
            login.Show();
        };

        var menuStrip = new MenuStrip {
            Items = { btBuy, btExit }
        };

        Controls.Add(menuStrip);
        Controls.Add(table);

        btBuy.Click += async (o, e) =>
        {
            await Buy(productId, userId);
            await LoadData(productId);
        };
    }

    void Clear()
        => table.Rows.Clear();
    
    void Add(string produto, string comprador, string data)
    {
        var row = new DataGridViewRow();
        row.Cells.Add(new DataGridViewTextBoxCell {
            Value = produto
        });
        row.Cells.Add(new DataGridViewTextBoxCell {
            Value = comprador
        });
        row.Cells.Add(new DataGridViewTextBoxCell {
            Value = data
        });
        table.Rows.Add(row);
    }
}