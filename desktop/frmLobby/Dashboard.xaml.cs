using System.Text;
using System.Text.Json;
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
using WindowLobby.crud;
using WindowLobby.CRUD;
using WindowLobby.CRUD.models;

namespace WindowLobby
{
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();

            ComporInformacoes();
            
        }

        public async void ComporInformacoes()
        {
            string token = Sessao.Token;

            var getUsu = await Usuario.GetUsuarios(token);
            var getVia = await Viagem.GetViagens(token);

            if (getUsu != null && getVia != null)
            {
                List<UsuarioModel> usuarios =
                JsonSerializer.Deserialize<
                    List<UsuarioModel>
                >(getUsu);

                //foreach (var usuario in usuarios)
                //{
                //    MessageBox.Show(
                //        usuario.nome
                //    );
                //}

                List<ViagemModel> viagens = JsonSerializer.Deserialize<
                    List<ViagemModel>
                >(getVia);
              

                gridUsuarios.ItemsSource = usuarios;

                txtUsuarios.Text = usuarios.Count.ToString();

            }
        }
    }
}