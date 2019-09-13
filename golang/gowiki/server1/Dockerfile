# Set base image
FROM ubuntu 
#AS serv1

# Copy binary into container
COPY wiki ./
COPY edit.html ./
COPY view.html ./
COPY test.txt ./

# Set proxy server
# ENV http_proxy http://hybrid-web.global.blackspider.com:8081/
# ENV https_proxy http://hybrid-web.global.blackspider.com:8081/

EXPOSE 8080

# Run the Go server as entrypoint in the container
ENTRYPOINT ["./wiki", "run"]
