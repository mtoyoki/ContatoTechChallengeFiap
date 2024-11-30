docker build -t mtoyoki/webapi:latest -f WebApi/Dockerfile .
docker push mtoyoki/webapi:latest 

docker build -t mtoyoki/worker-contato-create-queue-consumer:latest -f Service.ContatoCreateQueueConsumer/Dockerfile .
docker push mtoyoki/worker-contato-create-queue-consumer:latest 

docker build -t mtoyoki/worker-contato-update-queue-consumer:latest -f Service.ContatoUpdateQueueConsumer/Dockerfile .
docker push mtoyoki/worker-contato-update-queue-consumer:latest

docker build -t mtoyoki/worker-contato-delete-queue-consumer:latest -f Service.ContatoDeleteQueueConsumer/Dockerfile .
docker push mtoyoki/worker-contato-delete-queue-consumer:latest 
