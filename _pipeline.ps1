Write-host "Remove minikube if it was already running" -foregroundcolor green
minikube delete
Write-Host "Minikube was removed" -ForegroundColor Green

Write-Host "Start Minikube" -ForegroundColor Green
minikube start --vm-driver=hyperv Minikube
Write-Host "Minikube started" -ForegroundColor Green

Write-Host "Change Docker daemon to use the minikube VM" -ForegroundColor Green
minikube -p minikube docker-env --shell powershell | Invoke-Expression
Write-Host "Docker daemon setted" -ForegroundColor Green 

Write-Host "Configuring the namespace in the context" -ForegroundColor Green
kubectl config set-context engum --namespace=engum --cluster=minikube --user=minikube

kubectl config use-context engum
Write-Host "Context engum configured." -ForegroundColor Green

Write-Host "ingress is being installed" -ForegroundColor Green
minikube addons enable ingress
Write-Host "Ingress was enabled" -ForegroundColor Green

Write-Host "Generate the eng-api image" -ForegroundColor Green
docker build --no-cache -t eng-api:latest .
Write-Host "eng-api image was generated" -ForegroundColor Green

Write-Host "Installing the chart engum-chart" -ForegroundColor Green
$CmdBuild = "helm upgrade --install engum-chart ./eng-usermanager-chart --set image.repository=eng-api --set image.tag=latest --namespace=engum --create-namespace"
Write-Host "Chart engum-chart was installed" -ForegroundColor Green