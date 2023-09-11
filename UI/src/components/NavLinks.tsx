import { Button, Center, Flex, Text } from "@mantine/core";
import { NavLink } from "react-router-dom";
import { useAppSelector } from "../app/hooks";
import { useDispatch, useSelector } from "react-redux";
import { login, logout } from "../features/auth/authSlice";
import ToastNotify from "../components/ToastNotify";

type Link = {
  isActive: boolean;
  isPending: boolean;
};

const NavLinks = () => {
  const dispatch = useDispatch();
  const { isAuth, userType } = useSelector((state) => state.auth);
  const handleLogin = async (username: string, password: string) => {
    // login({
    //   "kullanicI_ADI": username,
    //   "sifre": password
    // });

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

  return (
    <Center py={20}>
      <Flex gap={20}>

        <NavLink
          to="/"
          className={({ isActive, isPending }: Link) =>
            isPending
              ? "pending"
              : isActive
                ? "text-green-500"
                : "text-gray-400"
          }
        >
          <Text>ANASAYFA</Text>
        </NavLink>

        {isAuth && (
          <>

            {userType === 0 ? (
              <>
                <NavLink
                  to="users"
                  className={({ isActive, isPending }) =>
                    isPending
                      ? "pending"
                      : isActive
                        ? "text-green-500"
                        : "text-gray-400"
                  }
                >
                  <Text>KULLANICILAR</Text>
                </NavLink>
                <NavLink
                  to="students"
                  className={({ isActive, isPending }) =>
                    isPending
                      ? "pending"
                      : isActive
                        ? "text-green-500"
                        : "text-gray-400"
                  }
                >
                  <Text>ÖĞRENCİLER</Text>
                </NavLink>
                <NavLink
                  to="mufredatlar"
                  className={({ isActive, isPending }) =>
                    isPending
                      ? "pending"
                      : isActive
                        ? "text-green-500"
                        : "text-gray-400"
                  }
                >
                  <Text>MÜFREDATLAR</Text>
                </NavLink>
                <NavLink
                  to="lessons"
                  className={({ isActive, isPending }) =>
                    isPending
                      ? "pending"
                      : isActive
                        ? "text-green-500"
                        : "text-gray-400"
                  }
                >
                  <Text>DERSLER</Text>
                </NavLink>
              </>
            ) :

              userType === 1 ? (
                <>
                  <NavLink
                    to="student-lessons"
                    className={({ isActive, isPending }) =>
                      isPending
                        ? "pending"
                        : isActive
                          ? "text-green-500"
                          : "text-gray-400"
                    }
                  >
                    <Text>KAYIT OLDUĞUM DERSLERİM</Text>
                  </NavLink>
                  <NavLink
                    to="mufredat-lessons"
                    className={({ isActive, isPending }) =>
                      isPending
                        ? "pending"
                        : isActive
                          ? "text-green-500"
                          : "text-gray-400"
                    }
                  >
                    <Text>MÜFREDATIMDAKİ DERSLER</Text>
                  </NavLink>
                  <NavLink
                    to="profile"
                    className={({ isActive, isPending }) =>
                      isPending
                        ? "pending"
                        : isActive
                          ? "text-green-500"
                          : "text-gray-400"
                    }
                  >
                    <Text>BİLGİLERİM</Text>
                  </NavLink>
                </>
              ) : ""
            }
          </>
        )}

        {isAuth ? (
          <Button onClick={() => dispatch(logout())}>Çıkış</Button>
        ) : ""}
      </Flex>
    </Center>
  );
};

export default NavLinks;
