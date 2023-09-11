import React, { lazy } from "react";
import ReactDOM from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import store from "./app";
import { Provider } from "react-redux";
import "./index.css";

import RootLayout from "./routes/RootLayout";
import { AdminOnly, Protected } from "./middleware/Protected";
import UsersLessons from "./routes/UserLessons";
import StudentLessons from "./routes/StudentLessons";
import MufredatLessons from "./routes/MufredatLessons";
import NewUser from "./routes/NewUser";
import NewMufredat from "./routes/NewMufredat";
import MufredatList from "./routes/MufredatList";
import NewLesson from "./routes/NewLesson";
import LessonList from "./routes/LessonList";
import LessonDetails from "./routes/LessonDetails";
import Students from "./routes/Students";
import StudentDetails from "./routes/StudentDetails";
import Profile from "./routes/Profile";
import ProfileEdit from "./routes/ProfileEdit";
import NewStudent from "./routes/NewStudent";
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
        path: "students",
        element: (
          <Protected>
            <Students />
          </Protected>
        ),
      },
      {
        path: "students/:id",
        element: (
          <Protected>
            <StudentDetails />
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
      {
        path: "student-lessons",
        element: (
          <Protected>
            <StudentLessons />
          </Protected>
        ),
      },
      {
        path: "mufredat-lessons",
        element: (
          <Protected>
            <MufredatLessons />
          </Protected>
        ),
      },
      {
        path: "mufredatlar",
        element: (
          <AdminOnly>
            <MufredatList />
          </AdminOnly>
        ),
      },
      {
        path: "new-mufredat",
        element: (
          <AdminOnly>
            <NewMufredat />
          </AdminOnly>
        ),
      },
      {
        path: "new-mufredat/:id",
        element: (
          <AdminOnly>
            <NewMufredat />
          </AdminOnly>
        ),
      },
      {
        path: "new-user",
        element: (
          <AdminOnly>
            <NewUser />
          </AdminOnly>
        ),
      },
      {
        path: "new-student",
        element: (
          <AdminOnly>
            <NewStudent />
          </AdminOnly>
        ),
      },
      {
        path: "new-user/:id",
        element: (
          <AdminOnly>
            <NewUser />
          </AdminOnly>
        ),
      },
      {
        path: "new-lesson",
        element: (
          <AdminOnly>
            <NewLesson />
          </AdminOnly>
        ),
      },
      {
        path: "new-lesson/:id",
        element: (
          <AdminOnly>
            <NewLesson />
          </AdminOnly>
        ),
      },
      {
        path: "lessons",
        element: (
          <AdminOnly>
            <LessonList />
          </AdminOnly>
        ),
      },
      {
        path: "profile",
        element: (
          <Protected>
            <Profile />
          </Protected>
        ),
      },
      {
        path: "edit-profile",
        element: (
          <Protected>
            <ProfileEdit />
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
