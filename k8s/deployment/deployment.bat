kubectl apply -f ./rabbitmq-deployment.yaml
kubectl apply -f ./sqlserver-deployment.yaml
kubectl apply -f ./webapi-deployment.yaml
kubectl apply -f ./worker-contato-create-queue-consumer-deployment.yaml
kubectl apply -f ./worker-contato-update-queue-consumer-deployment.yaml
kubectl apply -f ./worker-contato-delete-queue-consumer-deployment.yaml
kubectl apply -f ./prometheus-deployment.yaml
kubectl apply -f ./grafana-deployment.yaml