import React, { useState } from "react";
import { Navigate } from "react-router-dom";
import {
  Form,
  FormInput,
  FormGroup,
  Button,
  Container,
  Row,
  Col,
} from "shards-react";

const AuthWindow = () => {
  const [userName, setUserName] = useState("");
  const [password, setPassword] = useState("");
  const [redirect, setRedirect] = useState(false);

  const submit = async (e) => {
    e.preventDefault();
    console.log(userName);
    console.log(password);
    const response = await fetch("https://localhost:44349/login", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      credentials: "include",
      body: JSON.stringify({
        username: userName,
        password,
      }),
    });
    const content = await response.json();
    console.log(content);
    localStorage.setItem("token", JSON.stringify(content.token));

    setRedirect(true);
  };

  if (redirect) {
    return <Navigate to="/" />;
  }

  return (
    <div>
      <Container className="dr-example-container" style={{}}>
        <Row>
          <Col sm={{ size: 8, order: 2, offset: 2 }}>
            <h4>Please log in into system</h4>

            <Form onSubmit={submit}>
              <FormGroup>
                <label htmlFor="#username">Username</label>
                <FormInput
                  id="#username"
                  placeholder="Username"
                  required
                  onChange={(e) => setUserName(e.target.value)}
                />
              </FormGroup>
              <FormGroup>
                <label htmlFor="#password">Password</label>
                <FormInput
                  type="password"
                  id="#password"
                  placeholder="Password"
                  required
                  onChange={(e) => setPassword(e.target.value)}
                />
              </FormGroup>
              <Button className="float-right" type="submit">
                Login
              </Button>
            </Form>
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default AuthWindow;
