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
                <Text>ÖĞRENCİLER</Text>
              </NavLink>
            ) :

              userType === 1 ? (
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
                  <Text>DERSLERİM</Text>
                </NavLink>
              ) : ""
            }
          </>
        )}
      </Flex>
    </Center>
  );
};

export default NavLinks;
