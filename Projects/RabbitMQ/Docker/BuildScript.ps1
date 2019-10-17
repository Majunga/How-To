docker image build ./Send/ -t send:latest
docker image build ./Receive/ -t receive:latest

docker-compose up