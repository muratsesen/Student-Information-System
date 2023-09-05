import { Button } from "@mantine/core";
import { lazy, Suspense, useEffect, useRef } from "react";
import { useAppDispatch, useAppSelector } from "../app/hooks";
import { login, logout } from "../features/auth/authSlice";
import ToastNotify from "../components/ToastNotify";
import { useDispatch, useSelector } from "react-redux";
import { useLoginMutation } from "../features/apiSlice"

const Dashboard = lazy(() => import("./Dashboard"));

const Home = () => {
  const dispatch = useDispatch();
  const { isAuth } = useSelector((state) => state.auth);

  // const [login, {data:loginData, isSuccess: isSuccessLogin}] = useLoginMutation();

  // useEffect(() => {
  //   // const {data,status} = mutationResult;
  //   if(isSuccessLogin){
  //     console.log("success")
  //     localStorage.setItem("token", loginData.token);
  //       localStorage.setItem("ogrenciId", loginData.ogrenciId);
  //       localStorage.setItem("mufredatId", loginData.mufredatId);
  //       localStorage.setItem("userId", loginData.userId);
  //       console.log(loginData.userType,loginData.token)
  //       dispatch(login({ userType: loginData.userType, token: loginData.token }));
  //   }
  //     console.log(loginData)
    
  // } , [ isSuccessLogin])

  const handleLogin = async (username: string, password: string) => {
    // login({
    //   "kullanicI_ADI": username,
    //   "sifre": password
    // });
   
    fetch(`https://localhost:7277/Auth/giris`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Accept: "application/json",
        "Access-Control-Allow-Origin": "*",
        "Access-Control-Allow-Origin": "*",
      },
      body: JSON.stringify({
        "kullanicI_ADI": username,
        "sifre": password
      })
    })
      .then((res) => res.json())
      .then((data) => {
        console.log(data)
        localStorage.setItem("token", data.token);
        localStorage.setItem("ogrenciId", data.ogrenciId);
        localStorage.setItem("mufredatId", data.mufredatId);
        localStorage.setItem("userId", data.userId);
        dispatch(login({ userType: data.userType, token: data.token }));

      });

    // ToastNotify("Successfully logged in");
  };

  async function getUserInfo() {
    fetch("https://localhost:7277/Auth/info", {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Accept: "application/json",
        "Access-Control-Allow-Origin": "*",
        "Access-Control-Allow-Origin": "*",
      }
    })
      .then((res) => res.json())
      .then((data) => {
        console.log(data);
        // dispatch(login({ userType: data.userType, token: data.token }));
      });
  }

  return (
    <div>
      {isAuth ? (
        <Button onClick={() => dispatch(logout())}>Çıkış</Button>
      ) : (
        <Login handleLogin={handleLogin} />
      )}
      <Suspense fallback={<p>Loading...</p>}>
        {isAuth ? <Dashboard /> : <h1>Lütfen giriş yapınız!!</h1>}
      </Suspense>
    </div>
  );
};

function Login({ handleLogin }) {
  let usernameRef = useRef("fatma.korkmaz");
  let passwordRef = useRef("Fatkor12%");
  return (
    <div>
      {/* username and password */}
      <input ref={usernameRef} type="text" placeholder="Kullanıcı Adı" />
      <input ref={passwordRef} type="password" placeholder="Şifre" />
      <Button variant="gradient" onClick={() => handleLogin(usernameRef.current.value, passwordRef.current.value)} style={{ marginTop: "10px" }}>
        Giriş Yap
      </Button>
    </div>
  )

}
export default Home;
