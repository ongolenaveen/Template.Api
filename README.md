# Template.Api

This is a Template to create more structured, domain driven .net core Apis with mutiple data providers.
Technical Stack: .net core, c#, Nunit, FluentAssertions, OpenAPI 3.0.

# Hosting API in Azure Container Instance

Connect-AzAccount

Select-AzSubscription -SubscriptionName "Visual Studio Professional Subscription"

Connect-AzContainerRegistry -Name "jayasriltdcontainerregistry"

docker image build --file Template.App/Dockerfile --tag templateapi:latest .

docker container run -d --name templateapi -p 8085:80 templateapi:latest

docker tag templateapi:latest jayasriltdcontainerregistry.azurecr.io/templateapi:latest

docker push jayasriltdcontainerregistry.azurecr.io/templateapi:latest

docker pull jayasriltdcontainerregistry.azurecr.io/templateapi:latest

$container = New-AzContainerInstanceObject -Name test-container -Image jayasriltdcontainerregistry.azurecr.io/templateapi:latest
 
$imageRegistryCredential = New-AzContainerGroupImageRegistryCredentialObject -Server "jayasriltdcontainerregistry.azurecr.io" -Username "jayasriltdcontainerregistry" -Password (ConvertTo-SecureString "yourpassword" -AsPlainText -Force) 
 
$containerGroup = New-AzContainerGroup -ResourceGroupName JayasriLtdResourceGroup -Name naveen-template-app -Location eastus -Container $container -ImageRegistryCredential $imageRegistryCredential -IPAddressType Public
