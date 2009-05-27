package otra;

public class LoginManager 
{
	private String login;
	private String password;
	
	public LoginManager()
	{
	}
	
	public String getLogin() {
		return login;
	}

	public void setLogin(String login) {
		this.login = login;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String verify()
	{
		System.out.println("login:" + this.login);
		System.out.println("WAAAAHOUUUUUUUUUUUUU !!!!!");
		return "true";
	}
}
