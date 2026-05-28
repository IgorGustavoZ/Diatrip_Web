using System.Text;
using System.Text.Json.Nodes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowLobby;
using WindowLobby.crud;
using WindowLobby.CRUD;
namespace WindowLogin
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        async private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
           
            if(txtEmail.Text.Contains("@diartrip.com") && txtSenha.Password.Length == 5)
            {
                try{                  
                    var msg = await Usuario.Login(txtEmail.Text, txtSenha.Password);

                    if (msg != null)
                    {
                        JsonNode json = JsonNode.Parse(msg);

                        MessageBox.Show(json["mensagem"]?.GetValue<String>());
                     
                        Sessao.Token = json["token"]?.GetValue<String>();

                        Sessao.UsuarioId = json["usuario_id"]?.GetValue<int>() ?? 0;                       

                        Dashboard lobby = new Dashboard();

                        lobby.Show();
                        this.Close();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }               
            }
            else
            {
                MessageBox.Show("Informações inválidas.");
            }      
            
        }
    }
}