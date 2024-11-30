kubectl apply -f ./k8s/deployment/rabbitmq-deployment.yaml
kubectl apply -f ./k8s/deployment/sqlserver-deployment.yaml
kubectl apply -f ./k8s/deployment/webapi-deployment.yaml
kubectl apply -f ./k8s/deployment/grafana-deployment.yaml
kubectl apply -f ./k8s/deployment/prometheus-deployment.yaml
kubectl apply -f ./k8s/deployment/worker-contato-create-queue-consumer-deployment.yaml
kubectl apply -f ./k8s/deployment/worker-contato-update-queue-consumer-deployment.yaml
kubectl apply -f ./k8s/deployment/worker-contato-delete-queue-consumer-deployment.yaml