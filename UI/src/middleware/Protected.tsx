import { Navigate } from "react-router-dom";
import { useAppSelector } from "../app/hooks";
import { useSelector } from "react-redux";

export const Protected = ({ children }: any) => {
  const { isAuth } = useAppSelector((state) => state.auth);
  if (!isAuth) return <Navigate to={"/"} replace={true}></Navigate>;
  return children!;
};

export const AdminOnly = ({ children }: any) => {
  const { isAuth,userType } = useSelector((state) => state.auth);
  console.log("USER TYPE:", userType)
  if (!isAuth) return <Navigate to={"/"} replace={true}></Navigate>;
  if (userType !== 0) return <Navigate to={"/"} replace={true}></Navigate>;
  return children!;
};
