REM kubectl apply -f ./components.yaml
kubectl apply -f ./webapi-autoscaler.yaml
kubectl apply -f ./worker-contato-create-queue-consumer-autoscaler.yaml
kubectl apply -f ./worker-contato-update-queue-consumer-autoscaler.yaml
kubectl apply -f ./worker-contato-delete-queue-consumer-autoscaler.yaml