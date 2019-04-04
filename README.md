# 24h TinyUrl - Small distributed system
This service is used to keep your long url shortened for 24 hours  <br />
It uses redis distributed cache for the worker servers to access <br />
The load is distributed using round robin to worker servers <br />
WCF is used for remote procedure call <br />
