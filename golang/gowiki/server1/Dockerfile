# Set base image
FROM ubuntu AS serv1

# Copy binary into container
COPY wiki ./

# Set proxy server
# ENV http_proxy http://hybrid-web.global.blackspider.com:8081/
# ENV https_proxy http://hybrid-web.global.blackspider.com:8081/

# Make container's port 80 available to the world outside this container
EXPOSE 80

# Run the Go server as entrypoint in the container
ENTRYPOINT ["./wiki", "run"]
