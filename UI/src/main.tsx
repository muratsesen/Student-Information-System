import React, { lazy } from "react";
import ReactDOM from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import store  from "./app";
import { Provider } from "react-redux";
import "./index.css";

import RootLayout from "./routes/RootLayout";
import { Protected } from "./middleware/Protected";
import UsersLessons from "./routes/UserLessons";
const Users = lazy(() => import("./routes/Users"));
const UserDetails = lazy(() => import("./routes/UserDetails"));
const Home = lazy(() => import("./routes/Home"));
const Contact = lazy(() => import("./routes/Contact"));
const About = lazy(() => import("./routes/About"));
const ErrorPage = lazy(() => import("./routes/ErrorPage"));

const router = createBrowserRouter([
  {
    path: "/",
    element: <RootLayout />,
    errorElement: <ErrorPage />,
    children: [
      {
        path: "/",
        element: <Home />,
      },
      {
        path: "contact",
        element: <Contact />,
        children: [
          {
            path: "number",
            element: <h1> +90 551 123 45 67</h1>,
          },
          {
            path: "email",
            element: <h1>contactme@gmail.com</h1>,
          },
        ],
      },
      {
        path: "about",
        element: <About />,
      },
      {
        path: "users",
        element: (
          <Protected>
            <Users />
          </Protected>
        ),
      },
      {
        path: "users/:id",
        element: (
          <Protected>
            <UserDetails />
          </Protected>
        ),
      },
      {
        path: "registered-lessons/:id",
        element: (
          <Protected>
            <UsersLessons />
          </Protected>
        ),
      },
    ],
  },
]);

ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
  <React.StrictMode>
    <Provider store={store}>
      <RouterProvider router={router} />
    </Provider>
  </React.StrictMode>
);
