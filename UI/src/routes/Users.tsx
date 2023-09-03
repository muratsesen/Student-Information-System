import React, { useEffect } from "react";
import { Link } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../app/hooks";
import { fetchAllUsers } from "../features/user/userSlice";
import { Table } from "@mantine/core";

const Users = () => {
  const dispatch = useAppDispatch();
  const { users, status, error } = useAppSelector((state) => state.user);

  useEffect(() => {
    dispatch(fetchAllUsers()).unwrap();
  }, []);

  const data = users?.map((user) => (
    <tr key={user.id}>
      <td>{user.id}</td>
      <td>{user.name}</td>
      <td>
        <Link to={`/registered-lessons/${user.id}`}>Göster</Link>
      </td>
    </tr>
  ));

  return (
    <div>
      {status === "pending" ? (
        <h1>Fetching...</h1>
      ) : error ? (
        error
      ) : (
        <Table striped highlightOnHover withBorder withColumnBorders>
          <thead>
            <tr>
              <th>ID</th>
              <th>Ad Soyad</th>
              <th>Aldığı Dersler</th>
            </tr>
          </thead>
          <tbody>{data}</tbody>
        </Table>
      )}
    </div>
  );
};

export default Users;
