$currentLocation = Get-Location
Set-Location "c:\"
minikube start --vm-driver=hyperv --hyperv-virtual-switch "Default Switch" --memory=4096
Set-Location $currentLocation

& minikube docker-env | Invoke-Expression
docker build --rm -f ".\RabbitMQ\Receive\Dockerfile" -t receive:rabbitmq .\RabbitMQ\Receive
docker build --rm -f ".\RabbitMQ\Send\Dockerfile" -t send:rabbitmq .\RabbitMQ\Send
docker image pull rabbitmq:management

kubectl create -f .\rabbitmq.yml