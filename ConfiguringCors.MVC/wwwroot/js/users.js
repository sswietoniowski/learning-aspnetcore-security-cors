const clearUsersList = () => {
    const usersList = document.getElementById("users-list");
    usersList.innerHTML = "";
}

const createUsersList = (users) => {
    const usersList = document.getElementById("users-list");
    const rows = users.map(user => {
        return `
<div class="col col-md-3">
    <div class="card" style="width: 20rem;height: 35rem;">
        <div class="card-body">
            <img src="https://dummyimage.com/350x250/000/fff.jpg&text=${user.name}" class="card-img-top" alt="${user.name} Photo"/>
            <div class="card-body">
                <h5 class="card-title">${user.name}</h5>
                <h6 class="card-subtitle mb-2 text-muted">${user.userType}</h6>
                <p class="card-text">${user.biography}</p>
            </div>
        </div>
        <div class="card-footer">
            <ul class="list-group list-group-flush">
                <li class="list-group-item">${user.phoneNumber}</li>
                <li class="list-group-item"><a href="mailto:${user.email}" class="card-link">${user.email}</a></li>
                <li class="list-group-item"><a href="${user.website}" class="card-link">${user.website}</a></li>
            </ul>
        </div>
    </div>
</div>
`
    });
    const html = rows.join("");
    usersList.innerHTML = html;
}

const loadUsers = async (url) => {
    try {
        clearUsersList();
        const response = await fetch(url);
        const users = await response.json();
        createUsersList(users)
    } catch (err) {
        console.log(err);
        toastr.error(err);
    }
}
