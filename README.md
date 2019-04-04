# 24h TinyUrl
This service is used to keep your long url shortened for 24 hours \n
It uses redis distributed cache for the worker servers to access \n
The load is distributed using round robin to worker servers \n 
WCF is used for remote procedure call \n
