-------------------------------
- Setup inicial do Kubernetes -
-------------------------------

1. Nas configurações do Docker Desktop, acessar a aba Kubernetes e habilitar.

2. Alterar no arquivo C:\Users\mtmorinishi\.kube\config o server para https://localhost:6443
   Toda vez que resetar o Kubernetes será necessário alterar essa configuração novamente.

3. Realizar login no Docker Hub: docker login
   Usuário: mtoyoki
   Senha: 

4. Criar a imagem dos containeres e subir no Docker Hub:
> docker-publish.bat

5. Iniciar todos os containers:
> k8s\deployment\deployment.bat

6. Verificar se os pods estão em execução:
> kubectl get pods

7. Ativar auto scaler:
> k8s\autoscaler\autoscaler.bat

Obs: Se for a primeira execução, descomentar a linha 1: "kubectl apply -f ./components.yaml"

8. Criar o banco de dados. Abrir o Package Manager Console e executar o comando:
> Update-Database -StartupProject Infra.Data -Connection "Server=localhost;Database=DB_CONTATO;User=sa;Password=Password#2024;TrustServerCertificate=True"

--------------------------------
- Comandos Docker e Kubernetes -
--------------------------------

Para criar imagem do container Docker:
> docker build -t mtoyoki/worker-contato-create-queue-consumer:latest -f Service.ContatoCreateQueueConsumer/Dockerfile .

Para subir imagem para o Docker Hub:
> docker push mtoyoki/worker-contato-create-queue-consumer:latest 

Para subir container docker individualmente no Kubernetes:
> kubectl apply -f .\k8s\webapi-deployment.yaml

Para verificar os pods estão em execução:
> kubectl get pods

Para verificar os logs do pos:

> kubectl logs <nome_do_pod>
Exemplo: kubectl logs webapi-56cff54d5f-drsvc

Para apagar pod:
> kubectl delete pod worker-contato-create-queue-consumer-8cb5c5445-wr5kx