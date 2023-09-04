import { Center, Flex, Text } from "@mantine/core";
import { NavLink } from "react-router-dom";
import { useAppSelector } from "../app/hooks";
import { useSelector } from "react-redux";

type Link = {
  isActive: boolean;
  isPending: boolean;
};

const NavLinks = () => {
  const { isAuth, userType } = useSelector((state) => state.auth);
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
          <Text>Ana Sayfa</Text>
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
                    <Text>TÜM DERSLER</Text>
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
      </Flex>
    </Center>
  );
};

export default NavLinks;
