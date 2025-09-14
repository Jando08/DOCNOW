namespace DocNowApp.Login;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
		Login.LoginSQL acceso = new Login.LoginSQL(this.txtCorreo.Text, this.txtContrasenia.Text);

        //Validación por medio de un estadoLogin
        switch (await acceso.Validacion())
		{
			case LoginSQL.estadoLogin.Exito:
                await Shell.Current.GoToAsync("//PrincipalPage");
				break;
			case LoginSQL.estadoLogin.CredencialesIncorrectas:
				await DisplayAlert("Error", "Correo o contraseña incorrectos", "Aceptar");
				break;
			case LoginSQL.estadoLogin.Error:
				break;
        }

		//Validación por medio de un dato booleano
		/*if (await acceso.Validacion())
		{
            await Shell.Current.GoToAsync("//PrincipalPage");
        }
        else
		{
			await DisplayAlert("Error", "Correo o contraseña incorrectos", "Aceptar");
		}*/
    }
}