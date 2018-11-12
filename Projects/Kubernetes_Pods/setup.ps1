$currentLocation = Get-Location
Set-Location "c:\"
minikube start --vm-driver=hyperv --hyperv-virtual-switch "Default Switch" --memory=4096
Set-Location $currentLocation

& minikube docker-env | Invoke-Expression
docker build --rm -f ".\RabbitMQ\Receive\Dockerfile" -t receive:giantpod .\RabbitMQ\Receive
docker build --rm -f ".\RabbitMQ\Send\Dockerfile" -t send:giantpod .\RabbitMQ\Send
docker image pull rabbitmq:management

kubectl create -f .\giantpod.yml