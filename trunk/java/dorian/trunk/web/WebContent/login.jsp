<%@ taglib uri="http://java.sun.com/jsf/html" prefix="h"%>
<%@ taglib uri="http://java.sun.com/jsf/core" prefix="f"%>
<%@ taglib uri="http://myfaces.apache.org/tomahawk" prefix="t"%>

<html>
<head>
<title>System Login</title>
</head>
<body>
<f:view>
	<h:form>
		<h:panelGrid columns="2">
			<h:outputLabel value="User Name" for="j_username" />
			<t:inputText id="j_username" forceId="true"
				value="#{LoginManager.login}" size="40" maxlength="80">
			</t:inputText>
			<h:outputLabel value="Password" for="j_password" />
			<t:inputSecret id="j_password" forceId="true"
				value="#{LoginManager.password}" size="40" maxlength="80"
				redisplay="true">
			</t:inputSecret>
		</h:panelGrid>
		<h:commandButton action="#{LoginManager.verify}" value="log toi mon gard !!!"/>
		<h:messages id="messages" layout="table" globalOnly="true"
				showSummary="true" showDetail="false" />
	</h:form>
</f:view>
</body>
</html>


