const ConnectedUsers = ({users}) => <div className='user-list'>
    <h4>Connected Users</h4>
    {users.map((user, idx) =>
        <h6 key={idx}>
            {user}
        </h6>
    )}
</div>

export default ConnectedUsers;