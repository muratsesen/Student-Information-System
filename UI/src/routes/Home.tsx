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

try {
  fetch(`${import.meta.env.VITE_API_URL}Auth/giris`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Accept: "application/json",
      "Access-Control-Allow-Origin": "*",
    },
    body: JSON.stringify({
      "kullanicI_ADI": username,
      "sifre": password
    })
  })
    .then((res) => 
    {
      if(res.status === 401){
        ToastNotify("Kullanıcı adı veya şifre hatalı!")
        return
      }
      if(res.status === 404){
        ToastNotify("Kullanıcı adı veya şifre hatalı!")
        return
      }
      if(res.status === 500){
        ToastNotify("Kullanıcı adı veya şifre hatalı!")
        return
      }
      if(res.status === 403){
        ToastNotify("Kullanıcı adı veya şifre hatalı!")
        return
      }
      if(res.status === 400){
        ToastNotify("Kullanıcı adı veya şifre hatalı!")
        return
      }
      if(res.status === 200){
        ToastNotify("Başarılı bir şekilde giriş yaptınız!")
      }

      console.log("res:",res)
      res.json()
    }
   )
    .then((data) => {
      console.log(data)
      localStorage.setItem("token", data.token);
      localStorage.setItem("ogrenciId", data.ogrenciId);
      localStorage.setItem("mufredatId", data.mufredatId);
      localStorage.setItem("userId", data.userId);
      dispatch(login({ userType: data.userType, token: data.token }));

    });
} catch (error) {
  console.log(error)
}

    // ToastNotify("Successfully logged in");
  };

  async function getUserInfo() {
    try {
      fetch("https://localhost:7277/Auth/info", {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Accept: "application/json",
        "Access-Control-Allow-Origin": "*",
      }
    })
      .then((res) => res.json())
      .then((data) => {
        console.log(data);
        // dispatch(login({ userType: data.userType, token: data.token }));
      });
    } catch (error) {
      
    }
  }

  return (
    <div>
      {!isAuth && (
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
      <label htmlFor="username" className="mt-2 mb-2 block text-sm font-medium text-gray-700">
        Kullanıcı Adı
        <br />
        <input ref={usernameRef} type="text" placeholder="Kullanıcı Adı" />
      </label>

      <label htmlFor="password" className="mt-2 mb-2 block text-sm font-medium text-gray-700">
        Şifre
        <br />
        <input ref={passwordRef} type="password" placeholder="Şifre" />
      </label>
      <Button variant="gradient" onClick={() => handleLogin(usernameRef.current.value, passwordRef.current.value)} style={{ marginTop: "10px" }}>
        Giriş Yap
      </Button>
    </div>
  )

}
export default Home;
