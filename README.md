# TinyUrl
# This service is used to keep your long url shortened for 24 hours
# It uses redis distributed cache for the worker servers to access
# The load is distributed using round robin to worker servers
# WCF is used for remote procedure call
